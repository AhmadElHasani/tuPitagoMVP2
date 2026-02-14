export type ExerciseType = "Quiz" | "Learning";

export interface Exercise {
  id: string;
  title: string;
  topic: string;
  typology: string;
  type: ExerciseType;
  difficulty: number;
  pointsCorrect: number;
  pointsWrong: number;

  answer1: string;
  answer2: string;
  answer3: string;
  answer4: string;
  correctAnswerIndex: number;

  lastUpdate: string; // ISO date string
}
