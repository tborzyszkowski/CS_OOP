namespace Demo12.Code {
    public interface IApplicationSettings {
        int? WorkstationId { get; set; }
        string ApplicationVersion { get; set; }
        string RevisionNumber { get; set; }
        string SaveDirectory { get; set; }
    }
}