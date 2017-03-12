1.0.17.0
* Fix hash code overflow

1.0.16.0
* Update packages to align with other extensions (to avoid https://connect.microsoft.com/VisualStudio/feedback/details/2993889/)
* Visualize that projects with pending changes can't be edited.
* Project hierarchy is not properly refreshed after reload

1.0.15.0
* Fix issues with build configuration editing after unloading/reloading projects
 
1.0.14.0
* Fix #12: Also show unloaded projects and enable editing of properties.
* Use multiple choice filters instead of simple text filters where appropriate.

1.0.13.0
* Support VS2017 RC

1.0.12.0
* Fix: Defer property change notifications, else bulk operations on data grid will only execute partially

1.0.11.0
* Fix: Cell color not updated in the PropertiesView

1.0.10.0
* Fix: Project name missing in ProjectTypesView

1.0.9.0
* Add an interactive filter for tags

1.0.8.0
* Preserve properties column order
* Fix block copy issue when columns are reordered
* Fix some UI issues
* Properly load projects that do not implement "CopyLocal"

1.0.7.0
* Undo changes if project fails to load after saving.
* Add project types view
* Add dependencies view

1.0.6.0
* Fix #9: Add "Tag" column
* Fix #8: Remove empty columns
* Fix #7: Remove empty PropertyGroups in project files
* Fix #6: Skip web projects and other unloadable stuff.

1.0.5.0
* Do not create empty entries
* Commit changes to DataGrid after paste. (Last line was never updated)
* Show a wait cursor on lengthy operations
 
1.0.4.0
* Fix context menu in properties grid.
* Enable filtering in the build configuration grid.

1.0.3.0
* Add cell tooltip to ease navigation when the grid is dense.
* Fix co-existens problems with other plugins using DGX

1.0.2.0
* Fix copy/paste of complex cells.
* Improve robustness.
* Propert handling of implicit AnyCPU configurations. 
* Fix sorting in build configuration view.

1.0.1.0
* UX improvements.

1.0.0.0
* Initial version.
