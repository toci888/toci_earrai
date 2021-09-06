import { StyleSheet } from 'react-native';
import { color } from 'react-native-reanimated';

export const worksheetContentCSS = StyleSheet.create({
    addNewRecordView: {
        backgroundColor: '#365d96',

    },
    tableContainer: {
        width: 'auto'
    },
    customRow: {

    },
    cell: {
        color: 'black'
    },

    addNewRecordBtn: {

        backgroundColor: 'aqua',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 30,
        paddingBottom: 30,
        height: 50,
        fontSize: 17,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    },
    loadMoreView: {
        height: 60,
        backgroundColor: 'green',
        display: 'flex',
        justifyContent: 'center',
        margin: 15,
    },
    loadMoreText: {
        color: 'white',
        textAlign: 'center',
        fontSize: 18
    },
    nomoredataView: {
        marginTop: 10,
        padding: 22,
        backgroundColor: '#d6caca',

    },
    nomoredataText: {
        color: 'black',
        textAlign: 'center',
        fontSize: 18
    }

})