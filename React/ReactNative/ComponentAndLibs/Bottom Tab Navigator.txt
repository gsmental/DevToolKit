
npm install @react-navigation/bottom-tabs  (save)


import {createBottomTabNavigator} from '@react-navigation/bottom-tabs';

### Tab navigation and it will be called in Main-Navigation

const Tab = createBottomTabNavigator();
function MainTab() {
  return (
    // <Tab.Navigator tabBar={props => <TabBar {...props} />}>
    <Tab.Navigator>
      <Tab.Screen name="DashboardHome" component={DashboardHome}/>
      <Tab.Screen name="DashboardHome2" component={DashboardHome2}/>
      <Tab.Screen name="DashboardHome3" component={DashboardHome3}/>
    </Tab.Navigator>
  )
}


### Main navigation

const Stack = createStackNavigator();
export default function AppNavigator() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="SplashScreen">
      <Stack.Screen name="SplashScreen" component={SplashScreen} options={{headerShown:false,}} />
        <Stack.Screen name="AgreementLogin" component={AgreementLogin}  options={{headerShown:false}} />
        <Stack.Screen name="DashboardHome" component={MainTab}  options={{headerShown:false}} />
        <Stack.Screen
          name="MobileOtpVerification" options={{headerTitle:""}}
          component={MobileOtpVerification}
        />
       
      </Stack.Navigator>
    </NavigationContainer>
  );
}



## tab pages
import React from 'react'
import { View, Text } from 'react-native'

export default function DashboardHome() {
    return (
        <View>
            <Text>1 fdgyrgfd</Text>
        </View>
    )
}

export function DashboardHome2() {
    return (
        <View>
            <Text>2 daddd  </Text>
        </View>
    )
}

export function DashboardHome3() {
    return (
        <View>
            <Text>3 3w454rt</Text>
        </View>
    )
}

