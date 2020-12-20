###Tips
* **SafeAreaView** -- use SafeAreaView intead of View for fullScreenView Page, it will visible properly in Android/iOS
* **Text numberOfLines={1}** will truncate text if cross more than one line **This Is a Example of trancate tex...**
* **Platform Specific code**  import Platform,StatusBar from react-native  : PaddingTop: Platform.OS==="android" ? StatusBar.currentHeight :0 
* **npm install @react-native-community/hooks** use perfect output for ***AccessibilityInfo,AppState, BackHandler,CameraRoll, Clipboard,Dimensions, ImageDimensions, Keyboard, InteractionManager, DeviceOrientation,Layout*

####DeviceOrientation: it is perfect look for both pattern
* const {landscape}=useDeviceOrientation
* <View style={ width:'100%', height:landscape? '100%' : '30%'}></View>

