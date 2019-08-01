import { PostPhotos } from './post-photos';
import {WriteComment} from '../Dto/write-comment'

export interface GetPosts {
    ID: number;
    Description: string;
    Likes: number;
    PostDateTime: Date;
    UserId: string;
    UserName: string;
    UserImage: string;
    postPhotos: PostPhotos[];
    Comments: WriteComment[];
}
