import React, { useEffect, useState } from 'react'
import { Text, View, TextInput, Button, Left, Right } from 'react-native'
import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import Home from '../screens/Home'
import WorksheetContent from '../screens/WorksheetContent'
import WorksheetsList from '../screens/WorksheetsList'
import WorksheetRecord from '../screens/WorksheetRecord'
import Login from '../screens/Login'
import Register from '../screens/Register'
import { globalStyles } from '../styles/globalStyles'

export default function Header({navigation}) {
    return (<View style={{flexDirection:'row',justifyContent : 'space-between'}}>
        <View style={{flexDirection:'row',justifyContent : 'space-between'}}>
            <Text style={globalStyles.unityName}>Home / Workbooks</Text>
            {/* <Text style={globalStyles.subInfo}>Home / Workbooks2</Text> */}
        </View>
        <View style={{flexDirection: 'row', justifyContent: 'space-between'}}>
            <Text style={globalStyles.unityName} onPress={() => navigation.navigate('Login')}>Login</Text>
            <Text style={globalStyles.unityName} onPress={() => navigation.navigate('Register')}>Register</Text>
        </View>
    </View>);
}
