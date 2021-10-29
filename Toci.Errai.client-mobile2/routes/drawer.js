import { createDrawerNavigator } from '@react-navigation/drawer';
import { createAppContainer } from 'react-navigation';

import Login from './Auth/Login'
import Register from './Auth/Register'
import HomeStack from './homeStack';


const RootDrawerNavigator = createDrawerNavigator({
    Home: {
        screen: HomeStack,
    },
    Login: {
        screen: Login,
    },
    Register: {
        screen: Register,
    }
});


export default createAppContainer(RootDrawerNavigator);