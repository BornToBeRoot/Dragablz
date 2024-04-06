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
