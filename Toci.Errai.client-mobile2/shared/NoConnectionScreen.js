import React from 'react';
import { StyleSheet, View, Button, Image } from 'react-native';

const NoConnectionScreen = (props) => {
    return (
        <View style={styles.container}>
            <Image
                source={require('../assets/no_connections.png')}
                style={{ width: '30%', height: '30%' }}
                resizeMode="contain"
            />
            <Button title="Reload page" onPress={props.onCheck} />
        </View>
    )
}
const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'center',
    },
});
export default NoConnectionScreen
