import { StyleSheet } from 'react-native';

export const globalStyles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#ddd',
    },
    loading: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        marginTop: 25
    },
    loadingText: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        fontSize: 25,
    },
    fakeTable: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        paddingTop: 15,
        paddingBottom: 15,
        fontSize: 25,
        backgroundColor: 'rgb(204, 204, 204)'
    },
    header: {
        backgroundColor: 'yellow',
        paddingTop: 15,
        paddingBottom: 15,
    },
    lists: {
        backgroundColor: 'white',
        paddingTop: 10,
        paddingBottom: 10,
        // textAlign: 'center',
        borderBottomWidth: 2,
        borderBottomColor: 'rgb(204, 204, 204)',
    },
    content: {
        backgroundColor: 'white',
        borderTopColor: 'green',
        borderTopWidth: 3
    },
    item: {
        backgroundColor: 'blue',
        color: '#fff',
        borderBottomWidth: 1,
        borderBottomColor: 'rgb(204, 204, 204)',
        paddingTop: 10,
        paddingBottom: 10,
        borderBottomWidth: 1,
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

    },
    chooseWorkbookHeader: {
        backgroundColor: "#eee",
        paddingBottom: 15,
        paddingTop: 15,
        textAlign: 'center',
        fontSize: 25,
        borderBottomWidth: 1,
        borderBottomColor: 'rgb(204, 204, 204)',
    }



});


export const tabStyle = StyleSheet.create({
    cell: {
        fontSize: 7
    },

})