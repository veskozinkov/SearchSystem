namespace SearchSystem.Services.MainWindowServices
{
    interface IMainWindowService
    {
        public void InvokeSearchCompletedEvent(List<dynamic> records);
    }
}
