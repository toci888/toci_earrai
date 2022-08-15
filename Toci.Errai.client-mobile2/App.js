
import React from 'react';
import Navigator from './routes/homeStack'
import { NativeModules, Platform } from "react-native";

export default function App() {

    console.log("zaczynam ....");
console.log('jazda', NativeModules.I18nManager.localeIdentifier);

    //Localization.locale = 'gb';
    return (

        <Navigator />

    );
}

{/* </View> */}
{/*<View>
             <View style={styles.container}>
        <Text style={styles.item}>Try permissions</Text>
        <Button title="request permissions" onPress={requestCameraPermission} />
         </View> */}