
import { createStackNavigator } from 'react-navigation-stack'
import { createAppContainer } from 'react-navigation'
import Home from '../screens/Home'
import WorksheetContent from '../screens/WorksheetContent'
import WorksheetsList from '../screens/WorksheetsList'
import WorksheetRecord from '../screens/WorksheetRecord'


const screens = {
    Home: {
        screen: Home,
        navigationOptions: {
            title : "Home / Workbooks",
            headerStyle: { backgroundColor: '#ccc', color: '#ffffff' }
            // headerTitle : () => <Header />,
        }
    },
    WorksheetsList: {
        screen: WorksheetsList,
        navigationOptions: {
            title : "Worksheets List",
            headerStyle: { backgroundColor: '#ccc', color: '#66b3ff' }
        }
    },
    WorksheetContent: {
        screen: WorksheetContent,
        navigationOptions: {
            title : "Worksheets Content",
            headerStyle: { backgroundColor: '#ccc', color: '#66b3ff' }
        }
    },
    WorksheetRecord: {
        screen: WorksheetRecord,
        navigationOptions: {
            title : "Worksheets Record",
            headerStyle: { backgroundColor: '#ccc', color: '#66b3ff' }
        }
    }
}

const HomeStack = createStackNavigator(screens, {
    defaultNavigationOptions: {
        headerTintColor: '#444',
        headerStyle: { backgroundColor: '#eee', height: 70 }
    }
});



export default createAppContainer(HomeStack);
