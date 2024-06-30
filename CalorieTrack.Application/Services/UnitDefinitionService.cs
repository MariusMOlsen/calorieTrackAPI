using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;

namespace CalorieTrack.Services
{
    public class UnitDefinitionService: IUnitDefinitionService
    {
        private readonly IUnitDefinitionRepository _unitDefinitionRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UnitDefinitionService(IUnitDefinitionRepository unitDefinitionRepository, IUnitOfWork unitOfWork) { 
            _unitDefinitionRepository = unitDefinitionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UnitDefinitionDTO>> AddUnitDefition(string name, int defaultAmount)
        {
            Nutrition  dummyNutrition = new Nutrition(0, 0, 0, 0, Guid.NewGuid());
            UnitDefinition unitDefinition = new UnitDefinition(name, defaultAmount,dummyNutrition);
            _unitDefinitionRepository.Add(unitDefinition);
            await _unitOfWork.CommitChangesAsync();
            List<UnitDefinition> unitDefinitionList  = await _unitDefinitionRepository.GetAll();
            return UnitDefinitionDTO.convertFromEntityListToDTOList(unitDefinitionList);
        }

        public async Task<List<UnitDefinitionDTO>?> DeleteUnitDefinition(Guid Guid)
        {
            var foundUnitDefinition = await _unitDefinitionRepository.Find(Guid);

            if (foundUnitDefinition == null) {
                    return null;
            
            }
            _unitDefinitionRepository.Delete(foundUnitDefinition);
            await _unitOfWork.CommitChangesAsync();
            List<UnitDefinition> unitDefinitionList = await _unitDefinitionRepository.GetAll();
            return UnitDefinitionDTO.convertFromEntityListToDTOList(unitDefinitionList);
        }
        
        public async Task<List<UnitDefinitionDTO>> GetUnitDefinitions()
        {
            List<UnitDefinition> unitDefinitionList = await _unitDefinitionRepository.GetAll();
            return UnitDefinitionDTO.convertFromEntityListToDTOList(unitDefinitionList);
        }

        public async Task<UnitDefinitionDTO?> GetSingleUnitDefiniton(Guid Guid)
        {
            UnitDefinition unitDefinition = await _unitDefinitionRepository.Find(Guid);
            if(unitDefinition == null)
            {
                return null;
            }
            return UnitDefinitionDTO.convertFromEntityToDTO(unitDefinition);
        }
    }
}
