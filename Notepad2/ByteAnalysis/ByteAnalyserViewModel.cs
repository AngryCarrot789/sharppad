﻿using SharpPad.Utilities;

namespace SharpPad.ByteAnalysis
{
    public class ByteAnalyserViewModel : BaseViewModel
    {
        private char _character;
        public char Character
        {
            get => _character;
            set => RaisePropertyChanged(ref _character, value);
        }

        public void Update(Character character)
        {

        }
    }
}
