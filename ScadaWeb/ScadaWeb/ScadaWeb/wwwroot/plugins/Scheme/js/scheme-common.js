﻿// Contains common scheme objects.
// No dependencies.

// Namespaces
var scada = scada || {};
scada.scheme = scada.scheme || {};

// Compare operators enumeration
scada.scheme.CompareOperators = {
    EQUAL: 0,
    NOT_EQUAL: 1,
    LESS_THAN: 2,
    LESS_THAN_EQUAL: 3,
    GREATER_THAN: 4,
    GREATER_THAN_EQUAL: 5
};

// Logical operators enumeration
scada.scheme.LogicalOperators = {
    NONE: 0,
    AND: 1,
    OR: 2
};

// Horizontal alignments enumeration
scada.scheme.HorizontalAlignments = {
    LEFT: 0,
    CENTER: 1,
    RIGHT: 2
};

// Vertical alignments enumeration
scada.scheme.VerticalAlignments = {
    TOP: 0,
    CENTER: 1,
    BOTTOM: 2
};

// Image stretches enumeration
scada.scheme.ImageStretches = {
    NONE: 0,
    FILL: 1,
    ZOOM: 2
};

// Actions of a dynamic component enumeration
scada.scheme.Actions = {
    NONE: 0,
    DRAW_DIAGRAM: 1,
    SEND_COMMAND: 2,
    SEND_COMMAND_NOW: 3
};

// Kinds of displaying input channel value of a dynamic component
scada.scheme.ShowValueKinds = {
    NOT_SHOW: 0,
    SHOW_WITH_UNIT: 1,
    SHOW_WITHOUT_UNIT: 2
};

// Specifies the scale types
scada.scheme.ScaleTypes = {
    NUMERIC: 0,
    FIT_SCREEN: 1,
    FIT_WIDTH: 2
};

// Scheme calculations
scada.scheme.calc = {
    // Compare two values using the specified operator
    compare: function (val1, val2, compareOper) {
        var CompareOperators = scada.scheme.CompareOperators;

        switch (compareOper) {
            case CompareOperators.EQUAL:
                return val1 === val2;
            case CompareOperators.NOT_EQUAL:
                return val1 !== val2;
            case CompareOperators.LESS_THAN:
                return val1 < val2;
            case CompareOperators.LESS_THAN_EQUAL:
                return val1 <= val2;
            case CompareOperators.GREATER_THAN:
                return val1 > val2;
            case CompareOperators.GREATER_THAN_EQUAL:
                return val1 >= val2;
            default:
                return false;
        }
    },

    // Apply the logical operator to the two values
    isTrue: function (val1, val2, logicalOper) {
        var LogicalOperators = scada.scheme.LogicalOperators;

        switch (logicalOper) {
            case LogicalOperators.AND:
                return val1 && val2;
            case LogicalOperators.OR:
                return val1 || val2;
            default:
                return false;
        }
    },

    // Check if the condition is satisfied by the input channel value
    conditionSatisfied: function (cond, cnlVal) {
        var LogicalOperators = scada.scheme.LogicalOperators;
        var comp1 = this.compare(cnlVal, cond.compareArgument1, cond.compareOperator1);

        if (cond.logicalOperator === LogicalOperators.NONE) {
            return comp1;
        } else {
            var comp2 = this.compare(cnlVal, cond.compareArgument2, cond.compareOperator2);
            return this.isTrue(comp1, comp2, cond.logicalOperator);
        }
    }
};
