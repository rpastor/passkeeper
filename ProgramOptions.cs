namespace PassKeeper {

    enum CommandType {
        List,
        Add,
        Get,
        Update,
        Delete
    }

    class ProgramOptions {
        public CommandType CommandType { get; set; }
        public string ServiceName { get; set; }
        public string ServicePassword { get; set; }
        public string UnlockSecret { get; set; }
    }
}