namespace PassKeeper {

    public enum CommandType {
        Help,
        List,
        Add,
        Get,
        Update,
        Delete
    }

    public class ProgramOptions {
        public CommandType CommandType { get; set; }
        public string ServiceName { get; set; }
        public string ServicePassword { get; set; }
        public string UnlockSecret { get; set; }
    }
}