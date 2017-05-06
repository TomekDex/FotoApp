using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Annotations;

namespace FotoApp.Models.Drive
{
    public sealed class Drive : INotifyPropertyChanged
    {
        private string _content;
        private bool _isEnable;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public  DriveInfo DriveInfo { get; set; }

        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
