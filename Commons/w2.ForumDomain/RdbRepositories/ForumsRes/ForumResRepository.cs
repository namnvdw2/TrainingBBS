// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections;
using System.Linq;
using w2.AccountDomain.Domains.Users;
using w2.Common.Helper.Attribute;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Dto.ForumRes;
using w2.ForumDomain.RepositoryInterfaces.ForumsRes;
using w2.FoundationDomain.Helpers;
using w2.FoundationDomain.Repositories;

namespace w2.ForumDomain.RdbRepositories.ForumsRes
{
	/// <summary>
	/// Forum res repository
	/// </summary>
	internal sealed class ForumResRepository : IForumResRepository
	{
		private readonly ISqlRepository _repository;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumResRepository(ISqlRepository repository)
		{
			_repository = repository.WithResourceManager(Properties.Resources.ResourceManager).SetPageName("Forum");
		}

		/// <inheritdoc />
		public ForumRes[] GetResponse(ForumId[] ids)
		{
			var forumIds = ids
				.Select(x => x.AsInt)
				.ToArray();

			return _repository
				.GetWithBuilder<ForumResDto>(f =>
					f.Query("w2_ForumRes")
						.With("RankedForumRes", query => query
							.From("w2_ForumRes")
							.Select("w2_ForumRes.*")
							.Select("w2_Account.user_name")
							.SelectRaw("ROW_NUMBER() OVER (PARTITION BY w2_ForumRes.forum_id ORDER BY w2_ForumRes.date_created DESC) AS row_num")
							.Join("w2_Account", "w2_ForumRes.user_id", "w2_Account.id")
							.Where("w2_ForumRes.delete_flg", ForumDeleteFlagStatus.Active.ToDbValue())
							.WhereIn("w2_ForumRes.forum_id", forumIds))
						.From("RankedForumRes")
						.Where("row_num", "<=", 3))
				.Select(dto => ForumRes.CreateByDto(dto))
				.ToArray();
		}

		/// <inheritdoc />
		public void InsertResponse(ForumRes forum)
		{
			var dto = forum.CreateDto();
			dto.DateChanged = DateTime.Now;
			dto.DateCreated = DateTime.Now;

			var input = dto
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f => f.Query("w2_ForumRes").AsInsert(input));
		}

		/// <inheritdoc />
		public int DeleteByUserId(UserId id)
		{
			var result = _repository.ExecWithBuilder(f =>
				f.Query("w2_ForumRes")
				.Where("user_id", id.AsInt)
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
