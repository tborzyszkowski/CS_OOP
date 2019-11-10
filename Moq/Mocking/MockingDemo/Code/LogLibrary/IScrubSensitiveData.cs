namespace LogLibrary.Code {
    public interface IScrubSensitiveData {
        string From(string messageToScrub);
    }
}