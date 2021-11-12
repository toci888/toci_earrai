import { StyleSheet } from 'react-native';

export const modalStyles = StyleSheet.create({
    container: {
        backgroundColor: 'black',
        opacity: 0.4,
        zIndex: 22
    },
    loadingView: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    loadingText: {
        color: 'white',
        fontSize: 20
    },
    tempContainer: {
        position: 'absolute',
        top: 0,
        left: 0,
        width: '100%',
        height: '100%',
        flex: 1,
        backgroundColor: '#171819',
        opacity: 0.85,
        zIndex: 2000,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    },
    tempText: {
        color: 'white',
        fontSize: 35

    }

})