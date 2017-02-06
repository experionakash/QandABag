export class Question {
constructor(
        public  QuestionId :number,
        public  UserAsked :string,
        public  Title :string,
        public  Description :string,
        public  Status : boolean, 
        public  AnswerCount: number, 
        public  DateTimeAsked: string ){}
}
