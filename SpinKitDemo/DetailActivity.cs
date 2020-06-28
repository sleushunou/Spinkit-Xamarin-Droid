
using Android.App;
using Android.OS;
using Android.Support.Graphics.Drawable;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Github.Ybq.Android.Spinkit;
using Java.Lang;

namespace SpinKitDemo
{
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class DetailActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);
            var viewPager = FindViewById<ViewPager>(Resource.Id.view_pager);
            viewPager.OffscreenPageLimit = 0;
            viewPager.Adapter = new ViewPagerAdapter();
            viewPager.AddOnPageChangeListener(new ClickListener(Window));
            viewPager.SetCurrentItem(Intent.GetIntExtra("position", 0), true);
        }

        private class ClickListener : Object, ViewPager.IOnPageChangeListener
        {
            private readonly Window _window;

            public ClickListener(Window window)
            {
                _window = window;
            }

            public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
            {
                Object start = (int)Colors.Values[position % Colors.Values.Length];
                Object end = (int)Colors.Values[(position + 1) % Colors.Values.Length];

                int color = (int)ArgbEvaluator.Instance.Evaluate(positionOffset, start, end);
                _window.DecorView.SetBackgroundColor(new Android.Graphics.Color(color));
            }

            public void OnPageScrollStateChanged(int state)
            {
            }

            public void OnPageSelected(int position)
            {
                _window.DecorView.SetBackgroundColor(new Android.Graphics.Color((int)Colors.Values[position % Colors.Values.Length]));
            }
        }

        private class ViewPagerAdapter : PagerAdapter
        {
            public override int Count => SpinStyle.Values().Length;

            public override bool IsViewFromObject(View view, Object @object)
            {
                return view == @object;
            }

            public override Object InstantiateItem(ViewGroup container, int position)
            {
                var view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.item_pager, null);

                SpinKitView spinKitView = view.FindViewById<SpinKitView>(Resource.Id.spin_kit);
                var name = view.FindViewById<TextView>(Resource.Id.name);
                var style = SpinStyle.Values()[position];
                name.Text = style.Name().ToLower();
                var drawable = SpriteFactory.Create(style);
                spinKitView.SetIndeterminateDrawable(drawable);
                container.AddView(view);

                return view;
            }

            public override void DestroyItem(ViewGroup container, int position, Object @object)
            {
                container.RemoveView((View)@object);
            }
        }
    }
}
