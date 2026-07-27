// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections;
using System.Linq;
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
						.Select("w2_ForumRes.*")
						.Select("w2_Account.name as user_name")
						.Join("w2_Account", "w2_ForumRes.user_id", "w2_Account.id")
						.Where("w2_ForumRes.delete_flg", ForumDeleteFlagStatus.Active.ToDbValue())
						.WhereIn("forum_id", forumIds))
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
	}
}
