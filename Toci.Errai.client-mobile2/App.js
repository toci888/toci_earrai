
import React from 'react';
import { PermissionsAndroid } from 'react-native';
import Navigator from './routes/homeStack'






// const requestCameraPermission = async () => {
//     try {
//         const granted = await PermissionsAndroid.request(
//             PermissionsAndroid.PERMISSIONS.CAMERA,
//             {
//                 title: "Coll",
//                 message: "hehe",
//                 buttonNeutral: "Ask Me Later",
//                 buttonNegative: "Cancel",
//                 buttonPositive: "OK"
//             }
//         )
//         if (granted === PermissionsAndroid.RESULTS.GRANTED) {
//             console.log("You can use the camera");
//         } else {
//             console.log("Camera permission denied");
//         }
//     } catch (err) {
//         console.warn(err);
//     }
// }

export default function App() {


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