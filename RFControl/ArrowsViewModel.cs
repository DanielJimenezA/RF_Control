namespace RFControl
{
    public class ArrowsViewModel
    {
        public Command<DIRECTIONS> MoveCommand { get; set; }
        public ArrowsViewModel()
        {
            this.MoveCommand = new Command<DIRECTIONS>(RFController.Move);
        }
    }
}
