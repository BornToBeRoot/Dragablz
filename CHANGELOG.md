Features and fixes:
- Upgrade to .NET 8
- Fix [right click and drag will "lock" tab item](https://github.com/ButchersBoy/Dragablz/issues/132) via [this comment](https://github.com/ButchersBoy/Dragablz/issues/132#issuecomment-1317714396) and [Dragablz#275](https://github.com/ButchersBoy/Dragablz/pull/275)
  
  Files changed:
    - DragablzItem.cs (https://github.com/BornToBeRoot/Dragablz/blob/2b70e0f3a686372ea0ddd4d5bf58e5ac317edcaf/Dragablz/DragablzItem.cs#L483-L499)
- Use `DependencyProperty` for `Partition` in `InterTabController` and `Layout` to allow binding via [Dragablz#275](https://github.com/ButchersBoy/Dragablz/pull/275)
  
  Files changed:
    - InterTabController.cs (https://github.com/BornToBeRoot/Dragablz/blob/ac26a18c37827dd42677c731181be497e0306bbf/Dragablz/InterTabController.cs#L51-L62)
    - TabablzControl.cs (https://github.com/BornToBeRoot/Dragablz/blob/ac26a18c37827dd42677c731181be497e0306bbf/Dragablz/TabablzControl.cs#L976)
    - Dockablz\Layout.cs (https://github.com/BornToBeRoot/Dragablz/blob/ac26a18c37827dd42677c731181be497e0306bbf/Dragablz/Dockablz/Layout.cs#L195-L213, https://github.com/BornToBeRoot/Dragablz/blob/ac26a18c37827dd42677c731181be497e0306bbf/Dragablz/Dockablz/Layout.cs#L466)

- Fix closing tab in layout branch if `TabEmptiedResponse.DoNothing`

    Files changed:
        - TabEmptiedResponse.cs (https://github.com/BornToBeRoot/Dragablz/blob/7ac6fe4543daabd2ce381d80fa002eb9952dae3c/Dragablz/TabEmptiedResponse.cs#L10-L13)
        - TabablzControl.cs (https://github.com/BornToBeRoot/Dragablz/blob/7ac6fe4543daabd2ce381d80fa002eb9952dae3c/Dragablz/TabablzControl.cs#L1094-L1156)

- Feature: DependencyProperty to disable consolidate branch in TabalzControl added (e.g. to keep the main TabablzControl that is responsible for creating new tabs)
    Files changed:
        - TabablzControl.cs (https://github.com/BornToBeRoot/Dragablz/blob/a7575982a304493d44e5fe4ef726bc7c6ab0b070/Dragablz/TabablzControl.cs#L1110-L1170, https://github.com/BornToBeRoot/Dragablz/blob/a7575982a304493d44e5fe4ef726bc7c6ab0b070/Dragablz/TabablzControl.cs#L373-L388, https://github.com/BornToBeRoot/Dragablz/blob/a7575982a304493d44e5fe4ef726bc7c6ab0b070/Dragablz/TabablzControl.cs#L1261-L1268)

- Fix MahApps theme: use the `MahApps.Brushes.*` resource keys (`MahApps.xaml`)
- Update target framework to `net8.0-windows10.0.22621.0`
- Feature: Wider hit area for the grid splitters between layout branches (`Generic.xaml`)
- Upgrade to .NET 10 and update dependencies
    - Target framework is now `net10.0-windows` (no Windows SDK version)
    - `RuntimeIdentifier` / `PlatformTarget` removed from the library, the demo and the tests to allow native arm64 builds
    - `Dragablz.nuspec` now packs `net10.0-windows` only (the `netcoreapp3.0`, `net45` and `net40` targets are gone)
    - `DragablzDemo` uses `Microsoft.NET.Sdk` instead of the obsolete `Microsoft.NET.Sdk.WindowsDesktop`
    - `DragablzModernUIDemo` converted to an SDK style `net10.0-windows` project using MahApps.Metro 2.4.11

- Feature: Merge hint and larger merge area for tabs dragged as a window (opt-in, defaults unchanged)
    - `MergeTargetArea` (`HeaderItems` (default) / `HeaderPanel`): `HeaderPanel` also accepts a tab over the empty area of the tab bar (new optional template part `PART_HeaderPanel`, renamed from `HeaderContainerGrid` in the Generic and MaterialDesign templates)
    - `ShowMergeHint`, `MergeHintProximity` (default 48 DIPs) and `MergeHintTemplate` show a hint in the tab bar of every tab control the dragged tab can be merged into
    - Read-only `IsMergeTargetParticipating` / `IsMergeTargetOffered` for custom templates (a `MergeHintTemplate` is instantiated inside the tab control, bind with `RelativeSource AncestorType=TabablzControl`)
    - Vertical tab strips with fixed headers are now respected when searching a merge target; a tab dropped behind the last tab is inserted after it
- Fix `NullReferenceException` when starting a tab drag while `InterTabController.Partition` is `null` (`TabablzControl.ItemDragStarted`)
- Fix `NullReferenceException` when dragging a maximized `DragablzWindow` (`CriticalHandle` no longer reads a private `Window` property via reflection, it uses `WindowInteropHelper`)
- Tests: migrate the existing NUnit assertions to the NUnit 4 constraint model (`Assert.That`)
- Fix MahApps theme: `MahApps.Color.Accent2` is now `MahApps.Colors.Accent2` and the removed `WhiteBrush` is replaced by `MahApps.Brushes.IdealForeground` (`MahApps.xaml`)
