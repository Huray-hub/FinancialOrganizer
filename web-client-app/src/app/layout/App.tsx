import React, { Fragment, useContext, useEffect } from "react";
import { observer } from "mobx-react-lite";
import { withRouter } from "react-router-dom";
import { RouteComponentProps, Route } from "react-router";
import { RootStoreContext } from "../stores/rootStore";
import ModalContainer from "../common/modals/ModalContainer";
import HomePage from "../../features/home/HomePage";

const App: React.FC<RouteComponentProps> = ({ location }) => {
    const rootStore = useContext(RootStoreContext);
    const { setAppLoaded, token, appLoaded } = rootStore.commonStore;
    const { getUser, isLoggedIn, user } = rootStore.userStore;

    useEffect(() => {
        if (token) {
            getUser().then(() => setAppLoaded());
        } else {
            setAppLoaded();
        }
    }, [getUser, setAppLoaded, token]);

    if (!appLoaded) {
        /*Load Component here*/
    }

    return (
        <Fragment>
            <ModalContainer />
            {!isLoggedIn ? (
                <Route exact path="/" component={HomePage} />
            ) : (
                <Route path={"/(.+)"} render={() => <Fragment></Fragment>} />
            )}
        </Fragment>
    );
};

export default withRouter(observer(App));
