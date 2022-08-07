namespace teamServer.Models
{
    //abstract class: indicates missing components or incomplete implementation. prevents creation of objects these classes.
    //this class will be the base for creating any listener
    public abstract class Listener
    {
        public abstract string Name { get; }
        public abstract Task start();
        //task class represents a single operation, dose not return value and executes asynchronously.
        public abstract void stop();
    }
}
