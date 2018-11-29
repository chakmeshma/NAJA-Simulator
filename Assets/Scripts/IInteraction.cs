public interface IInteraction {
    bool isInputBlocking();
    void run();
    bool isRunning();
    string getDescription();
}
