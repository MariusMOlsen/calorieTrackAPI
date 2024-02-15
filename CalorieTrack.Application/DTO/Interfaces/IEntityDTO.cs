using CalorieTrack.Model;

namespace CalorieTrack.DTO.Interfaces
{
    public interface IEntityDTO<T>
    {
        List<T> convertFromEntityListToDTOList(List<T> entityList);
    }
}
