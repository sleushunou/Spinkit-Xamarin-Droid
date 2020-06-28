using System;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Github.Ybq.Android.Spinkit.Style;

namespace SpinKitDemo
{
    public class WidgetFragment : Fragment
    {
        private Wave _mWaveDrawable;
        private Circle _mCircleDrawable;
        private ChasingDots _mChasingDotsDrawable;

        public static WidgetFragment NewInstance()
        {
            return new WidgetFragment();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_widget, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            //ProgressBar
            var progressBar = view.FindViewById<ProgressBar>(Resource.Id.progress);
            var doubleBounce = new DoubleBounce();
            doubleBounce.SetBounds(0, 0, 100, 100);
            doubleBounce.Color = (int)Colors.Values[7];
            progressBar.SetIndeterminateDrawableTiled(doubleBounce);

            //Button
            var button = view.FindViewById<Button>(Resource.Id.button);
            _mWaveDrawable = new Wave();
            _mWaveDrawable.SetBounds(0, 0, 100, 100);
            //noinspection deprecation
            _mWaveDrawable.Color = Resources.GetColor(Resource.Color.colorAccent);
            button.SetCompoundDrawables(_mWaveDrawable, null, null, null);

            //TextView
            TextView textView = view.FindViewById<TextView>(Resource.Id.text);
            _mCircleDrawable = new Circle();
            _mCircleDrawable.SetBounds(0, 0, 100, 100);
            _mCircleDrawable.Color = Color.White;
            textView.SetCompoundDrawables(null, null, _mCircleDrawable, null);
            textView.SetBackgroundColor(new Color((int)Colors.Values[2]));

            //ImageView
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.image);
            _mChasingDotsDrawable = new ChasingDots();
            _mChasingDotsDrawable.Color = Color.White;
            imageView.SetImageDrawable(_mChasingDotsDrawable);
            imageView.SetBackgroundColor(new Color((int)Colors.Values[0]));
        }

        public override void OnResume()
        {
            base.OnResume();
            _mWaveDrawable.Start();
            _mCircleDrawable.Start();
            _mChasingDotsDrawable.Start();
        }

        public override void OnStop()
        {
            base.OnStop();
            _mWaveDrawable.Stop();
            _mCircleDrawable.Stop();
            _mChasingDotsDrawable.Stop();
        }
    }
}
