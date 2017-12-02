# Space-Racer

## Summary

## GDD




## IMPORTANT Checklist
### In the beginning

#### Per User
- [ ] \(Optional) Move content in "GameEngine Data" to your Unity installation to override default C# script

#### Per Team 
- [x] Change /unity-project-folder/ name
- [x] Decide folder structure (!_Game_ByAssetType vs !_Game_ByEntity) Rename to !_Game, delete unwanted one   
- [ ] Decide what thirdparty libraries to use      
- [ ] Update .gitignore in /unity-project-folder/ to include or exlude third party libraries. Prefix with ! to flip folders
- [ ] Don't commit PAID libraries if going open source     
- [x] Set Company name in "Project Settings > Player Settings" to team name   
- [x] Set Product name in "Project Settings > Player Settings" to project name   
- [x] Decide Time Settings (Default timestep is 0.02, project is set to 0.04)    
- [x] Decide script structures (Update default c# monobehaviour-script if needed)
- [x] If you're using a newer unity version, check if .gitignore is still valid; 
 
### At the end

#### Per Team Before Final build
- [ ] Backup project     
- [ ] Set final Company name in "Project Settings > Player Settings"     
- [ ] Set final Product name in "Project Settings > Player Settings"      
- [ ] Remove paid tools      
- [ ] Double check paid tools from commit history if going public    
- [ ] Remove placeholders       
- [ ] Add Unity version used to the readme
- [ ] Add Third party tools versions to the readme
- [ ] WebGL: Remove exceptions handling

### Optimization Checklist
- [ ] Remove empty Update methods
- [ ] Cache components
- [ ] Profile
- [ ] Merge meshes    
- [ ] Texture atlases    
- [ ] Share materials
--------

## List of Thirdparty Libraries and tools
TODO: Remove unused 

### DOTween Pro
An Animation and tweening library.   
PAID  
https://www.assetstore.unity3d.com/en/#!/content/32416   
Or Use the Free version (below)  

* Demigiant/DOTweenPro
* Resources/DOTweenSettings.asset

### DOTween
An Animation and tweening library.  
Free   
https://www.assetstore.unity3d.com/en/#!/content/27676    
Or use the paid version (above)  

* Demigiant/DOTween
* Resources/DOTweenSettings.asset

### ProBuilder Basic
3D Level tool.   
Free    
https://www.assetstore.unity3d.com/en/#!/content/11919    

* ProCore/ProBuilder


### Unity Toolbag
Scripting Tools   
Free   
https://github.com/nickgravelyn/UnityToolbag     
Omitted: SimpleSpriteAnimation, SortingLayer, SyncSolution    
 
* UnityToolbag-master/CacheBehaviour
* UnityToolbag-master/Dispatcher
* UnityToolbag-master/Future
* UnityToolbag-master/SnapToSurface
* UnityToolbag-master/StandardPaths
* UnityToolbag-master/UnityConstants

###  Consolation
View console ingame    
Free    
https://github.com/mminer/consolation    

* consolation-master/

