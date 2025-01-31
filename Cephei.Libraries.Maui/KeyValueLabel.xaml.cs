namespace Cephei.Libraries.Maui;

/// <summary>
/// KeyValueLabels are labels that contain a bolded key and a normal value text.
/// </summary>
public partial class KeyValueLabel : ContentView
{
	/// <summary>
	/// Instantiates a KeyValueLabel.
	/// </summary>
	public KeyValueLabel()
	{
		InitializeComponent();
		BindingContext = this;
	}

  #region public

  /// <summary>
  /// Gets or sets the label's style.
  /// </summary>
  public Style LabelStyle
  {
    set => SetValue(LabelStyleProperty, value);
    get => (Style)GetValue(LabelStyleProperty);
  }
  /// <summary>
  /// The LabelStyle property.
  /// </summary>
  public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(nameof(LabelStyle), typeof(Style), typeof(KeyValueLabel));

  /// <summary>
  /// Gets or sets the key's text
  /// </summary>
  public string KeyText
  {
    set => SetValue(KeyTextProperty, value);
    get => (string)GetValue(KeyTextProperty);
  }
  /// <summary>
  /// The KeyText property.
  /// </summary>
  public static readonly BindableProperty KeyTextProperty = BindableProperty.Create(nameof(KeyText), typeof(string), typeof(KeyValueLabel));

  /// <summary>
  /// Gets or sets the value's text
  /// </summary>
  public string ValueText
  {
    set => SetValue(ValueTextProperty, value);
    get => (string)GetValue(ValueTextProperty);
  }
  /// <summary>
  /// The ValueText property.
  /// </summary>
  public static readonly BindableProperty ValueTextProperty = BindableProperty.Create(nameof(ValueText), typeof(string), typeof(KeyValueLabel));

  #endregion
}