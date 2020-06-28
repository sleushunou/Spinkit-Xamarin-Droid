using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Java.Lang;

namespace SpinKitDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TabLayout _mTabLayout;
        private ViewPager _mViewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _mTabLayout = (TabLayout)FindViewById(Resource.Id.tabs);
            _mViewPager = (ViewPager)FindViewById(Resource.Id.viewpager);

            _mViewPager.Adapter = new MainFragmentPagerAdapter(SupportFragmentManager);
            _mTabLayout.SetupWithViewPager(_mViewPager);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private class MainFragmentPagerAdapter : FragmentPagerAdapter
        {
            String[] _titles = new String[]{
                new String("Style"),
                new String("Widget")
            };

            public MainFragmentPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {
            }

            public override int Count => 2;

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                if (position == 0)
                {
                    return StyleFragment.NewInstance();
                }
                else
                {
                    return WidgetFragment.NewInstance();
                }
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return _titles[position];
            }
        }
    }
}