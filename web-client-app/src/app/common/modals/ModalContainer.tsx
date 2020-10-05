import React, { useContext } from "react"
import { RootStoreContext } from "../../stores/rootStore"
import Modal from 'react-bootstrap/Modal';
import { observer } from "mobx-react-lite";

const ModalContainer = () => {
    const rootStore = useContext(RootStoreContext);
    const {
        modal: {open, body},
        closeModal
    } = rootStore.modalStore;

    return (
        <Modal show={open} onHide={closeModal}>
            <Modal.Body>{body}</Modal.Body>
        </Modal>
    );
};

export default observer(ModalContainer);