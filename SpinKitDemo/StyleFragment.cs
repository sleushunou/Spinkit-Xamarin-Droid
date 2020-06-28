using System;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Github.Ybq.Android.Spinkit;
using Com.Github.Ybq.Android.Spinkit.Sprite;
using Java.Interop;

namespace SpinKitDemo
{
    public class StyleFragment : Fragment
    {
        public static StyleFragment NewInstance()
        {
            return new StyleFragment();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_style, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.list);
            var layoutManager = new GridLayoutManager(Context, 4);
            layoutManager.Orientation = RecyclerView.Vertical;
            recyclerView.SetLayoutManager(layoutManager);

            recyclerView.SetAdapter(new StyleFragmentAdapter());
        }

        private class StyleFragmentAdapter : RecyclerView.Adapter
        {
            public override int ItemCount => SpinStyle.Values().Length;

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_style, null);
                return new Holder(view);
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var viewHolder = (Holder)holder;
                viewHolder.Bind(position);
            }
        }

        private class Holder : RecyclerView.ViewHolder
        {
            private SpinKitView _spinKitView;

            public Holder(View itemView) : base (itemView)
            {
                _spinKitView = itemView.FindViewById<SpinKitView>(Resource.Id.spin_kit);
            }

            public void Bind(int position)
            {
                ItemView.SetBackgroundColor(new Android.Graphics.Color((int)Colors.Values[position % Colors.Values.Length]));
                ItemView.SetOnClickListener(new ClickListener(position));

                SpinStyle style = SpinStyle.Values()[position & 15];
                Sprite drawable = SpriteFactory.Create(style);
                _spinKitView.SetIndeterminateDrawable(drawable);
            }

            private class ClickListener : Java.Lang.Object, View.IOnClickListener
            {
                private readonly int _position;

                public ClickListener(int position)
                {
                    _position = position;
                }

                public void OnClick(View v)
                {
                    var intent = new Intent(v.Context, typeof(DetailActivity));
                    intent.PutExtra("position", _position);
                    v.Context.StartActivity(intent);
                }
            }
        }
    }
}
