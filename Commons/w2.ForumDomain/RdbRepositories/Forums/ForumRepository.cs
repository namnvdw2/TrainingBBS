// (c) 2025 W2 Co.,Ltd.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using w2.Common.Helper.Attribute;
using w2.ForumDomain.Common;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Dto.ForumRes;
using w2.ForumDomain.Dto.Forums;
using w2.ForumDomain.RepositoryInterfaces.Forums;
using w2.FoundationDomain.Helpers;
using w2.FoundationDomain.Repositories;

namespace w2.ForumDomain.RdbRepositories.Forums
{
	/// <summary>
	/// Forum repository
	/// </summary>
	public sealed class ForumRepository : IForumRepository
	{
		private readonly ISqlRepository _repository;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumRepository(ISqlRepository repository)
		{
			_repository = repository.WithResourceManager(Properties.Resources.ResourceManager).SetPageName("Forum");
		}

		/// <inheritdoc />
		public PaginationResult<Forum> GetAll(int page, int pageSize)
		{
			var query = _repository
				.GetWithBuilder<ForumDto>(f =>
					f.Query("w2_Forum")
						.Select("w2_Forum.*")
						.Select("w2_Account.name as user_name")
						.Join("w2_Account", "w2_Forum.user_id", "w2_Account.id")
						.Where("w2_Forum.delete_flg", ForumDeleteFlagStatus.Active.ToDbValue())
						.OrderByDesc("w2_Forum.date_created"));
			var totalCount = query.Count();

			var skip = Math.Max(0, (page - 1) * pageSize);

			var forums = query
				.Skip(skip)
				.Take(pageSize)
				.Select(dto => Forum.CreateByDto(dto))
				.ToArray();

			return new PaginationResult<Forum>(forums, totalCount);
		}

		/// <inheritdoc />
		public Forum? Get(ForumId id)
		{
			var dto = _repository
				.GetWithBuilder<ForumDto>(f =>
					f.Query("w2_Forum")
					.Where("forum_id", id.AsInt))
				.FirstOrDefault();
			return dto is not null ? Forum.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public ForumResDto[] GetResponse(ForumId[] ids)
		{
			var forumIds = ids
				.Select(x => x.AsInt)
				.ToArray();

			return _repository
				.GetWithBuilder<ForumResDto>(f =>
					f.Query("w2_ForumRes")
						.Select("w2_ForumRes.*")
						.Select("w2_Account.name as user_name")
						.Join("w2_Account", "w2_ForumRes.user_id", "w2_Account.id")
						.Where("w2_ForumRes.delete_flg", ForumDeleteFlagStatus.Active.ToDbValue())
						.WhereIn("forum_id", forumIds))
				.ToArray();
		}

		/// <inheritdoc />
		public void Insert(Forum forum)
		{
			forum.DateChanged = new DateChanged(DateTime.Now);
			forum.DateCreated = new DateCreated(DateTime.Now);
			var input = forum
				.CreateDto()
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f => f.Query("w2_Forum").AsInsert(input));
		}

		/// <inheritdoc />
		public void InsertResponse(ForumRes forum)
		{
			forum.DateChanged = new DateChanged(DateTime.Now);
			forum.DateCreated = new DateCreated(DateTime.Now);
			var input = forum
				.CreateDto()
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f => f.Query("w2_ForumRes").AsInsert(input));
		}

		/// <inheritdoc />
		public int Update(Forum forum)
		{
			forum.DateChanged = new DateChanged(DateTime.Now);
			var input = forum
				.CreateDto()
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			var result = _repository.ExecWithBuilder(f =>
				f.Query("w2_Forum")
					.Where("forum_id", forum.ForumId.AsInt)
					.AsUpdate(input));

			return result;
		}

		/// <inheritdoc />
		public int Delete(ForumId id)
		{
			var result = _repository.ExecWithBuilder(f =>
				f.Query("w2_Forum")
				.Where("forum_id", id.AsInt)
				.Where("delete_flg", ForumDeleteFlagStatus.Active.ToDbValue())
				.AsUpdate(new
				{
					delete_flg = ForumDeleteFlagStatus.Deleted.ToDbValue(),
					date_changed = DateTime.Now
				}));
			return result;
		}
	}
}
