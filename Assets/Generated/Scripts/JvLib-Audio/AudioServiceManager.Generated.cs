namespace JvLib.Audio
{
    public partial class AudioServiceManager // Generated
    {
        public JvLib.Audio.MasterMixer Master { get; private set; }
        public JvLib.Audio.LoopMixer Music { get; private set; }
        public JvLib.Audio.ParallelMixer Sfx { get; private set; }
        public JvLib.Audio.ParallelMixer UI { get; private set; }

        protected override void RegisterMixers()
        {
            Master = new JvLib.Audio.MasterMixer();
            Master.Register(transform, JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[0]);
            Music = new JvLib.Audio.LoopMixer();
            Music.Register(transform, JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[1]);
            Sfx = new JvLib.Audio.ParallelMixer();
            Sfx.Register(transform, JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[2]);
            UI = new JvLib.Audio.ParallelMixer();
            UI.Register(transform, JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[3]);
        }
        protected override void InitializeMixers()
        {
            Master.Initialize(JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[0].DefaultVolume);
            Music.Initialize(JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[1].DefaultVolume);
            Sfx.Initialize(JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[2].DefaultVolume);
            UI.Initialize(JvLib.Settings.ProjectSettings.Instance.Audio.Mixers[3].DefaultVolume);
        }
    }
}

