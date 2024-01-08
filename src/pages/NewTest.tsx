import { useParams } from 'react-router';
import Editor from '../components/Editor';

const NewTest = () => {
    const { id } = useParams();
    const editorStyle = {
        height: 'calc(100% - 2px)' // Add your styles here
    };
    return (
        <>
            <div style={editorStyle}>
                <Editor id={id as string}/>
            </div>
        </>
    );
}

export default NewTest;
