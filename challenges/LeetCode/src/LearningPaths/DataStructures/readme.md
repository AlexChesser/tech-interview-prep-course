cp ../template_blank _217_ContainsDuplicate.cs && sed -i -E "s/replaceme/_217_ContainsDuplicate/" _217_ContainsDuplicate.cs
cp ../template_blank _53_MaximumSubarray.cs && sed -i -E "s/replaceme/_53_MaximumSubarray/" _53_MaximumSubarray.cs
cp ../template_blank _88_MergeSortedArray.cs && sed -i -E "s/replaceme/_88_MergeSortedArray/" _88_MergeSortedArray.cs
cp ../template_blank _350_IntersectionofTwoArraysII.cs && sed -i -E "s/replaceme/_350_IntersectionofTwoArraysII/" _350_IntersectionofTwoArraysII.cs
cp ../template_blank _566_ReshapetheMatrix.cs && sed -i -E "s/replaceme/_566_ReshapetheMatrix/" _566_ReshapetheMatrix.cs
cp ../template_blank _36_ValidSudoku.cs && sed -i -E "s/replaceme/_36_ValidSudoku/" _36_ValidSudoku.cs
cp ../template_blank _74_Searcha2DMatrix.cs && sed -i -E "s/replaceme/_74_Searcha2DMatrix/" _74_Searcha2DMatrix.cs
cp ../template_blank _387_FirstUniqueCharacterinaString.cs && sed -i -E "s/replaceme/_387_FirstUniqueCharacterinaString/" _387_FirstUniqueCharacterinaString.cs
cp ../template_blank _383_RansomNote.cs && sed -i -E "s/replaceme/_383_RansomNote/" _383_RansomNote.cs
cp ../template_blank _242_ValidAnagram.cs && sed -i -E "s/replaceme/_242_ValidAnagram/" _242_ValidAnagram.cs
cp ../template_blank _141_LinkedListCycle.cs && sed -i -E "s/replaceme/_141_LinkedListCycle/" _141_LinkedListCycle.cs
cp ../template_blank _232_ImplementQueueusingStacks.cs && sed -i -E "s/replaceme/_232_ImplementQueueusingStacks/" _232_ImplementQueueusingStacks.cs
cp ../template_blank _144_BinaryTreePreorderTraversal.cs && sed -i -E "s/replaceme/_144_BinaryTreePreorderTraversal/" _144_BinaryTreePreorderTraversal.cs
cp ../template_blank _94_BinaryTreeInorderTraversal.cs && sed -i -E "s/replaceme/_94_BinaryTreeInorderTraversal/" _94_BinaryTreeInorderTraversal.cs
cp ../template_blank _145_BinaryTreePostorderTraversal.cs && sed -i -E "s/replaceme/_145_BinaryTreePostorderTraversal/" _145_BinaryTreePostorderTraversal.cs
cp ../template_blank _102_BinaryTreeLevelOrderTraversal.cs && sed -i -E "s/replaceme/_102_BinaryTreeLevelOrderTraversal/" _102_BinaryTreeLevelOrderTraversal.cs
cp ../template_blank _104_MaximumDepthofBinaryTree.cs && sed -i -E "s/replaceme/_104_MaximumDepthofBinaryTree/" _104_MaximumDepthofBinaryTree.cs
cp ../template_blank _101_SymmetricTree.cs && sed -i -E "s/replaceme/_101_SymmetricTree/" _101_SymmetricTree.cs
cp ../template_blank _226_InvertBinaryTree.cs && sed -i -E "s/replaceme/_226_InvertBinaryTree/" _226_InvertBinaryTree.cs
cp ../template_blank _112_PathSum.cs && sed -i -E "s/replaceme/_112_PathSum/" _112_PathSum.cs
cp ../template_blank _700_SearchinaBinarySearchTree.cs && sed -i -E "s/replaceme/_700_SearchinaBinarySearchTree/" _700_SearchinaBinarySearchTree.cs
cp ../template_blank _701_InsertintoaBinarySearchTree.cs && sed -i -E "s/replaceme/_701_InsertintoaBinarySearchTree/" _701_InsertintoaBinarySearchTree.cs
cp ../template_blank _98_ValidateBinarySearchTree.cs && sed -i -E "s/replaceme/_98_ValidateBinarySearchTree/" _98_ValidateBinarySearchTree.cs
cp ../template_blank _653_TwoSumIVInputisaBST.cs && sed -i -E "s/replaceme/_653_TwoSumIVInputisaBST/" _653_TwoSumIVInputisaBST.cs
cp ../template_blank _235_LowestCommonAncestorofaBinarySearchTree.cs && sed -i -E "s/replaceme/_235_LowestCommonAncestorofaBinarySearchTree/" _235_LowestCommonAncestorofaBinarySearchTree.cs


mkdir DAY01 && mv -t DAY01 

for i in 01 02 03 04 05 06 07 08 09 10 11 12 13 14
do
    mkdir "DAY$i"
done

for i in 15 16 17 18 19 20 21
do
    mkdir "DAY$i"
done

_217_ContainsDuplicate _53_MaximumSubarray
_88_MergeSortedArray
_350_IntersectionofTwoArraysII _566_ReshapetheMatrix
_36_ValidSudoku _74_Searcha2DMatrix 
_387_FirstUniqueCharacterinaString _383_RansomNote _242_ValidAnagram
_141_LinkedListCycle 
_232_ImplementQueueusingStacks
_144_BinaryTreePreorderTraversal
_94_BinaryTreeInorderTraversal
_145_BinaryTreePostorderTraversal
_102_BinaryTreeLevelOrderTraversal
_104_MaximumDepthofBinaryTree
_101_SymmetricTree
_226_InvertBinaryTree
_112_PathSum
_700_SearchinaBinarySearchTree
_701_InsertintoaBinarySearchTree
_98_ValidateBinarySearchTree
_653_TwoSumIVInputisaBST
_235_LowestCommonAncestorofaBinarySearchTree