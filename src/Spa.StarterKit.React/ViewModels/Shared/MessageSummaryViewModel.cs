using System.Collections.Generic;
using System.Linq;
using MPD.Electio.SDK.NetCore.Error;

namespace Spa.StarterKit.React.ViewModels.Shared
{
    public class MessageSummaryViewModel
    {
        private List<string> _errorMessages;
        private List<string> _infoMessages;
        private List<string> _warningMessages;
        private List<string> _successMessages;

        public MessageSummaryViewModel()
        {            
            _errorMessages = new List<string>();
            _infoMessages = new List<string>();
            _warningMessages = new List<string>();
            _successMessages = new List<string>();
        }

        public MessageSummaryViewModel(string header) : this()
        {
            Header = header;
        }

        public ApiError ApiError { get; set; }

        public string Header { get; set; }

        public string[] ErrorMessages
        {
            get
            {
                var errors = _errorMessages.ToList();

                ApiError?.Details?.ForEach(f =>
                {
                    errors.Add(f.Message);
                });

                return errors.Distinct().ToArray();
            }
        }

        public string[] InfoMessages
        {
            get { return _infoMessages.Distinct().ToArray(); }
        }

        public string[] WarningMessages
        {
            get { return _warningMessages.Distinct().ToArray(); }
        }

        public string[] SuccessMessages
        {
            get { return _successMessages.Distinct().ToArray(); }
        }

        public void AddError(string message)
        {
            _errorMessages.Add(message);
        }

        public void AddWarning(string message)
        {
            _warningMessages.Add(message);
        }

        public void AddInfo(string message)
        {
            _infoMessages.Add(message);
        }

        public void AddSuccess(string message)
        {
            _successMessages.Add(message);
        }
    }
}