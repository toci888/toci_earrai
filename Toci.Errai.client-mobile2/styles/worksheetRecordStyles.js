import { StyleSheet } from 'react-native';

export const worksheetRecord = StyleSheet.create({
    item: {
        borderTopWidth: 12,
        borderTopColor: '#807373',
    },
    listItem: {
        backgroundColor: 'white',
        color: 'black',
        paddingTop: 15,
        paddingBottom: 15,
        textAlign: 'center',
    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        textAlign: 'center',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        paddingLeft: 10,
        fontSize: 17,
        width: '100%',

    },
    updateButtonContainer: {
        width: '15%',
        height: '100%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#5c5b61',
        color: 'white',
    },
    updateButton: {
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    }

})