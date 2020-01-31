import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

// STATE - This defines the type of data maintained in the Redux store.
export interface BlogPostsState {
    isLoading: boolean;
    startDateIndex?: number;
    posts: BlogPost[];
}

export interface BlogPost {
    date: string;
    author: string;
    title: string;
    summary: string;
}

// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
interface RequestBlogPostsAction {
    type: 'REQUEST_BLOG_POSTS';
    startDateIndex: number;
}

interface ReceiveBlogPostsAction {
    type: 'RECEIVE_BLOG_POSTS';
    startDateIndex: number;
    posts: BlogPost[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestBlogPostsAction | ReceiveBlogPostsAction;

// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
export const actionCreators = {
    requestBlogPosts: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.BlogPosts && startDateIndex !== appState.BlogPosts.startDateIndex) {
            fetch(`blogpost`)
                .then(response => response.json() as Promise<BlogPost[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_BLOG_POSTS', startDateIndex: startDateIndex, posts: data });
                });

            dispatch({ type: 'REQUEST_BLOG_POSTS', startDateIndex: startDateIndex });
        }
    }
};

// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
const unloadedState: BlogPostsState = { posts: [], isLoading: false };

export const reducer: Reducer<BlogPostsState> = (state: BlogPostsState | undefined, incomingAction: Action): BlogPostsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_BLOG_POSTS':
            return {
                startDateIndex: action.startDateIndex,
                posts: state.posts,
                isLoading: true
            };
        case 'RECEIVE_BLOG_POSTS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    posts: action.posts,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
