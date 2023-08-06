//using System.Threading.Tasks;
//using EasyMicroservices.Mapper.CompileTimeMapper.Interfaces;
//using EasyMicroservices.Mapper.Interfaces;
//using System.Linq;

//namespace CompileTimeMapper
//{
//    public class CommentEntity_CommentContract_Mapper : IMapper
//    {
//        readonly IMapperProvider _mapper;
//        public CommentEntity_CommentContract_Mapper(IMapperProvider mapper)
//        {
//            _mapper = mapper;
//        }
//        public global::EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity Map(global::EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity()
//            {
//                Name = fromObject.Name,
//                Text = fromObject.Text,
//                Email = fromObject.Email,
//                Website = fromObject.Website,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModifiationDateTime = fromObject.ModifiationDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity,
//            };
//            return mapped;
//        }
//        public global::EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract Map(global::EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract()
//            {
//                Name = fromObject.Name,
//                Text = fromObject.Text,
//                Email = fromObject.Email,
//                Website = fromObject.Website,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModifiationDateTime = fromObject.ModifiationDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity,


//            };
//            return mapped;
//        }
//        public async Task<global::EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity> MapAsync(global::EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity()
//            {
//                Id = fromObject.Id,
//                Name = fromObject.Name,
//                Text = fromObject.Text,
//                Email = fromObject.Email,
//                Website = fromObject.Website,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModifiationDateTime = fromObject.ModifiationDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity,


//            };
//            return mapped;
//        }
//        public async Task<global::EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract> MapAsync(global::EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract()
//            {
//                Id = fromObject.Id,
//                Name = fromObject.Name,
//                Text = fromObject.Text,
//                Email = fromObject.Email,
//                Website = fromObject.Website,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModifiationDateTime = fromObject.ModifiationDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity,

//            };
//            return mapped;
//        }
//        public object MapObject(object fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            if (fromObject.GetType() == typeof(EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity))
//                return Map((EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity)fromObject, uniqueRecordId, language, parameters);
//            return Map((EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract)fromObject, uniqueRecordId, language, parameters);
//        }
//        public async Task<object> MapObjectAsync(object fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            if (fromObject.GetType() == typeof(EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity))
//                return await MapAsync((EasyMicroservices.CommentsMicroservice.Database.Entities.CommentEntity)fromObject, uniqueRecordId, language, parameters);
//            return await MapAsync((EasyMicroservices.CommentsMicroservice.Contracts.Common.CommentContract)fromObject, uniqueRecordId, language, parameters);
//        }
//    }
//}