public class CountereService{
    protected internal ICounter Counter {get;}

    public CountereService(ICounter counter){
        Counter = counter;
    }
}