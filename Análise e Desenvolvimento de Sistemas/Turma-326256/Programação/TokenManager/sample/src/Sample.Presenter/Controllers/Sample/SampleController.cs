namespace Sample.Presenter.Controllers.Sample
{
    public class SampleController : Controller
    {
        private reaonly SampleAppService _sampleAppService;

        public SampleController(SampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }
    }
}