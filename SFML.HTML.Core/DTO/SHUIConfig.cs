
namespace SFML.HTML.Core.DTO
{
    /// <summary>
    /// Ui display configuration
    /// </summary>
    public class SHUIConfig
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        public List<SHUIState> States { get; set; } = new List<SHUIState>();
    }
}
