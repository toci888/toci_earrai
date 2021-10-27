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
        backgroundColor: '#cccccc'
    },
    header: {
        backgroundColor: '#4a4a30',
        paddingTop: 15,
        textAlign: 'center',
        paddingBottom: 15,
    },
    headerText: {
        color: 'yellow'
    },
    lists: {
        backgroundColor: 'white',
        //paddingTop: 10,
        textAlign: 'center',
        borderBottomWidth: 2,
        borderBottomColor: '#cccccc',
    },
    content: {
        backgroundColor: 'white',
        borderTopColor: 'green',
        borderTopWidth: 3,
        flex: 1,
    },
    listItem: {
        backgroundColor: '#cccccc',
        color: 'black',
        paddingTop: 15,
        paddingBottom: 15,
        borderBottomWidth: 1,
        borderBottomColor: '#b1b1b1',
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
        borderBottomColor: '#cccccc',
    },
    cell: {
        fontSize: 7,
        padding: 4,
        color: 'black'
        //clear: 'both'
        //borderLeftWidth: 1,
        //borderBottomWidth: 1,
        //borderBottomColor: 'blue',
    },
    tableContainer: {
        display: 'flex',
        justifyContent: 'center',
        color: 'black'
    },
    HalfHeader: {
        backgroundColor: '#c6c4f3',
        color: 'black',
        borderWidth: 0
    },
    // containerProducts:{
    //     paddingTop: 40,
    //     paddingLeft: 15,
    //     flexDirection: 'row',
    //      },
    productName: {
        alignSelf: 'flex-start',
    },
    minus:{
        width: 20,
        height: 20,
        borderRadius: 20/2,
        backgroundColor: 'red',
    },
    containerInfo:{
        paddingTop:15,
        flexDirection:'row',
        paddingLeft: 15,
    },
    unityName:{
        fontWeight: 'bold',
        paddingLeft: 15,
        fontSize: 20,
        margin: 20
    },
    subInfo:{
        color: 'gray',
        paddingLeft: 15,
    },
    circle: {
        width: 50,
        height: 50,
        borderRadius: 50/2,
        backgroundColor: 'red',
        justifyContent: 'flex-end',
    },
    containerProducts: {
        paddingTop: 40,
        paddingLeft: 15,
        flexDirection: 'row',
        justifyContent: 'space-between',
    },
    noConnectionView: {
        margin: 10,
        backgroundColor: '#ea7272',
        borderColor: '#860c0c',
        borderWidth: 3
    },
    noConnectionText: {
        color: 'black',
        fontSize: 25,
        textAlign: 'center',
        padding: 20
    },
    reloadView: {
        margin: 10,
        backgroundColor: '#b7aeae',
        borderColor: '#948484',
        borderWidth: 3
    },
    reloadText: {
        color: 'black',
        fontSize: 25,
        textAlign: 'center',
        padding: 20
    }


});
