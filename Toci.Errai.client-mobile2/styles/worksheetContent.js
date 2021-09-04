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
        width: 'fit-content',
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

})