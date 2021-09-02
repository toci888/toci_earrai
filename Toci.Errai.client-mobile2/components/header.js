import React from 'react'
import { Text, View } from 'react-native'
import { globalStyles } from '../styles/globalStyles'

export default function Header({navigation}) {
    return (
    <View style={{flexDirection:'row',justifyContent : 'space-between'}}>
        <View style={{flexDirection:'row',justifyContent : 'space-between'}}>
            <Text style={globalStyles.unityName}>Home / Workbooks</Text>
        </View>
        <View style={{flexDirection: 'row', justifyContent: 'space-between'}}>
            <Text style={globalStyles.unityName} onPress={() => navigation.navigate('Login')}>Logout</Text>
        </View>
    </View>);
}
