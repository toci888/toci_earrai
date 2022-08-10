import NetInfo from '@react-native-community/netinfo';

export const checkConnected = (callback) => {
    return NetInfo.fetch().then(state => {
        console.log('Connection type', state.type);
        console.log('Is connected?', state.isConnected);
        callback(state.isConnected);
      });
}