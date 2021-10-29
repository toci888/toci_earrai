import { StyleSheet } from 'react-native';
import { color } from 'react-native-reanimated';

export const ProductStyle = StyleSheet.create({
    addNewRecordView: {
        backgroundColor: '#365d96',

    },
    tableContainer: {
        width: 'auto'
    },
    customRow: {
        marginLeft: 10,
        marginRight: 10,
    },
    cell: {
        color: 'black'
    },
    small: {
        fontSize: 12
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
    },
    filterContent: {
        margin: 15,
        flexDirection: 'row',

    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        paddingLeft: 10,
        fontSize: 17,
        width: '80%'

    },
    filterInput: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 15,
        paddingBottom: 15,
        paddingLeft: 10,
        fontSize: 17,
        width: '75%'
    },
    filterButtonView: {
        width: '25%',
    },
    filterButton: {
        height: 58,
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#6f1111'
    },
    textUpdate: {
        color: 'white',
        fontSize: 20
    }

})