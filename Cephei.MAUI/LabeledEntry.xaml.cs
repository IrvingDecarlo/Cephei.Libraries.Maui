namespace Cephei.MAUI;

/// <summary>
/// The LabeledEntry contains a label next to the entry, specifying to the user the entry's functionality.
/// </summary>
public partial class LabeledEntry : ContentView
{
	/// <summary>
	/// Creates a new labeled entry.
	/// </summary>
	public LabeledEntry()
	{
		InitializeComponent();
		BindingContext = this;
	}

  #region public

	/// <summary>
	/// Is the list of the entry's behaviors.
	/// </summary>
	public IList<Behavior> EntryBehaviors => EntryMain.Behaviors;

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
  public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(nameof(LabelStyle), typeof(Style), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the entry's style.
  /// </summary>
  public Style EntryStyle
  {
    set => SetValue(EntryStyleProperty, value);
    get => (Style)GetValue(EntryStyleProperty);
  }
  /// <summary>
  /// The EntryStyle property.
  /// </summary>
  public static readonly BindableProperty EntryStyleProperty = BindableProperty.Create(nameof(EntryStyle), typeof(Style), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the entry's keyboard.
  /// </summary>
  public Keyboard Keyboard
  {
    set => SetValue(KeyboardProperty, value);
    get => (Keyboard)GetValue(KeyboardProperty);
  }
  /// <summary>
  /// The Keyboard property.
  /// </summary>
  public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the label's text
  /// </summary>
  public string Label
  {
    set => SetValue(LabelProperty, value);
    get => (string)GetValue(LabelProperty);
  }
  /// <summary>
  /// The label property.
  /// </summary>
  public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the entry's text
  /// </summary>
  public string Text
  {
    set => SetValue(TextProperty, value);
    get => (string)GetValue(TextProperty);
  }
  /// <summary>
  /// The text property.
  /// </summary>
  public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the entry's placeholder.
  /// </summary>
  public string Placeholder
  {
    set => SetValue(PlaceholderProperty, value);
    get => (string)GetValue(PlaceholderProperty);
  }
  /// <summary>
  /// The placeholder property.
  /// </summary>
  public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the entry's max length.
  /// </summary>
  public int MaxLength
  {
    set => SetValue(MaxLengthProperty, value);
    get => (int)GetValue(MaxLengthProperty);
  }
  /// <summary>
  /// The max length property.
  /// </summary>
  public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the spacing between the entry and the label.
  /// </summary>
  public int Spacing
  {
    set => SetValue(SpacingProperty, value);
    get => (int)GetValue(SpacingProperty);
  }
  /// <summary>
  /// The Spacing property.
  /// </summary>
  public static readonly BindableProperty SpacingProperty = BindableProperty.Create(nameof(Spacing), typeof(int), typeof(LabeledEntry));

  /// <summary>
  /// Gets or sets the entry's password check
  /// </summary>
  public bool IsPassword
  {
    set => SetValue(IsPasswordProperty, value);
    get => (bool)GetValue(IsPasswordProperty);
  }
  /// <summary>
  /// The Is Password property.
  /// </summary>
  public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(LabeledEntry));

  #endregion
}