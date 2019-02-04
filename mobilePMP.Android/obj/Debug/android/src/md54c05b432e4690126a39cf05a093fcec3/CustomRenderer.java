package md54c05b432e4690126a39cf05a093fcec3;


public class CustomRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("mobilePMP.Droid.CustomRenderer, mobilePMP.Android", CustomRenderer.class, __md_methods);
	}


	public CustomRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomRenderer.class)
			mono.android.TypeManager.Activate ("mobilePMP.Droid.CustomRenderer, mobilePMP.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CustomRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomRenderer.class)
			mono.android.TypeManager.Activate ("mobilePMP.Droid.CustomRenderer, mobilePMP.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomRenderer.class)
			mono.android.TypeManager.Activate ("mobilePMP.Droid.CustomRenderer, mobilePMP.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
